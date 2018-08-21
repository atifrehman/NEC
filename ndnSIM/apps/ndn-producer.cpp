/* -*- Mode:C++; c-file-style:"gnu"; indent-tabs-mode:nil; -*- */
/**
 * Copyright (c) 2011-2015  Regents of the University of California.
 *
 * This file is part of ndnSIM. See AUTHORS for complete list of ndnSIM authors and
 * contributors.
 *
 * ndnSIM is free software: you can redistribute it and/or modify it under the terms
 * of the GNU General Public License as published by the Free Software Foundation,
 * either version 3 of the License, or (at your option) any later version.
 *
 * ndnSIM is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR
 * PURPOSE.  See the GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License along with
 * ndnSIM, e.g., in COPYING.md file.  If not, see <http://www.gnu.org/licenses/>.
 **/

#include "ndn-producer.hpp"
#include "ns3/log.h"
#include "ns3/string.h"
#include "ns3/uinteger.h"
#include "ns3/packet.h"
#include "ns3/simulator.h"

#include "model/ndn-l3-protocol.hpp"
#include "helper/ndn-fib-helper.hpp"

#include <memory>

#include<boost/asio.hpp>

using boost::asio::ip::tcp;

NS_LOG_COMPONENT_DEFINE("ndn.Producer");

namespace ns3 {
namespace ndn {

NS_OBJECT_ENSURE_REGISTERED(Producer);

TypeId
Producer::GetTypeId(void)
{
  static TypeId tid =
    TypeId("ns3::ndn::Producer")
      .SetGroupName("Ndn")
      .SetParent<App>()
      .AddConstructor<Producer>()
      .AddAttribute("Prefix", "Prefix, for which producer has the data", StringValue("/"),
                    MakeNameAccessor(&Producer::m_prefix), MakeNameChecker())
      .AddAttribute(
         "Postfix",
         "Postfix that is added to the output data (e.g., for adding producer-uniqueness)",
         StringValue("/"), MakeNameAccessor(&Producer::m_postfix), MakeNameChecker())
      .AddAttribute("PayloadSize", "Virtual payload size for Content packets", UintegerValue(1024),
                    MakeUintegerAccessor(&Producer::m_virtualPayloadSize),
                    MakeUintegerChecker<uint32_t>())
      .AddAttribute("Freshness", "Freshness of data packets, if 0, then unlimited freshness",
                    TimeValue(Seconds(0)), MakeTimeAccessor(&Producer::m_freshness),
                    MakeTimeChecker())
      .AddAttribute(
         "Signature",
         "Fake signature, 0 valid signature (default), other values application-specific",
         UintegerValue(0), MakeUintegerAccessor(&Producer::m_signature),
         MakeUintegerChecker<uint32_t>())
      .AddAttribute("KeyLocator",
                    "Name to be used for key locator.  If root, then key locator is not used",
                    NameValue(), MakeNameAccessor(&Producer::m_keyLocator), MakeNameChecker());
  return tid;
}

Producer::Producer()
{
  NS_LOG_FUNCTION_NOARGS();
}

// inherited from Application base class.
void
Producer::StartApplication()
{
  NS_LOG_FUNCTION_NOARGS();
  App::StartApplication();

  FibHelper::AddRoute(GetNode(), m_prefix, m_face, 0);
}

void
Producer::StopApplication()
{
  NS_LOG_FUNCTION_NOARGS();

  App::StopApplication();
}

void
Producer::OnInterest(shared_ptr<const Interest> interest)
{
  this->GetContentFromEdge();
  
  App::OnInterest(interest); // tracing inside

  NS_LOG_FUNCTION(this << interest);

  if (!m_active)
    return;

  Name dataName(interest->getName());
  // dataName.append(m_postfix);
  // dataName.appendVersion();

  auto data = make_shared<Data>();
  data->setName(dataName);
  data->setFreshnessPeriod(::ndn::time::milliseconds(m_freshness.GetMilliSeconds()));

  data->setContent(make_shared< ::ndn::Buffer>(m_virtualPayloadSize));

  Signature signature;
  SignatureInfo signatureInfo(static_cast< ::ndn::tlv::SignatureTypeValue>(255));

  if (m_keyLocator.size() > 0) {
    signatureInfo.setKeyLocator(m_keyLocator);
  }

  signature.setInfo(signatureInfo);
  signature.setValue(::ndn::makeNonNegativeIntegerBlock(::ndn::tlv::SignatureValue, m_signature));

  data->setSignature(signature);

  NS_LOG_INFO("node(" << GetNode()->GetId() << ") responding with Data: " << data->getName());

  // to create real wire encoding
  data->wireEncode();

  m_transmittedDatas(data, this, m_face);
  m_appLink->onReceiveData(*data);
}

void
Producer::GetContentFromEdge()
{
try {

    boost::asio::io_service io_service;

    std::string const address = "192.168.84.1"; // 

    // Get a list of endpoints corresponding to the server name.

    tcp::resolver resolver(io_service);

    tcp::resolver::query query(address, "80", boost::asio::ip::resolver_query_base::numeric_service);



    tcp::resolver::iterator endpoint_iterator = resolver.resolve(query);



    

    

    // Try each endpoint until we successfully establish a connection.

    tcp::socket socket(io_service);



    boost::asio::connect(socket, endpoint_iterator);



    // Form the request. We specify the "Connection: close" header so that the

    // server will close the socket after transmitting the response. This will

    // allow us to treat all data up until the EOF as the content.

    boost::asio::streambuf request;

    std::ostream request_stream(&request);

    request_stream << "GET " << "/api/Sample/ComputeHash?nodeType=gateway2&nodeName=centralizecontrolle2r" << " HTTP/1.1\r\n";

    request_stream << "Host: " << address << "\r\n";

    request_stream << "Accept: */*\r\n";

    request_stream << "Connection: close\r\n\r\n";



    // Send the request.

    boost::asio::write(socket, request);



    // Read the response status line. The response streambuf will automatically

    // grow to accommodate the entire line. The growth may be limited by

    // passing a maximum size to the streambuf constructor.

    boost::asio::streambuf response;

    boost::asio::read_until(socket, response, "\r\n");



    // Check that response is OK.

    std::istream response_stream(&response);

    std::string http_version, status_message;

    unsigned int status_code;

    std::getline(response_stream >> http_version >> status_code, status_message);



    if (!response_stream || http_version.substr(0, 5) != "HTTP/") {

        std::cout << "Invalid response\n";

        return;

    }

    if (status_code != 200) {

        std::cout << "Response returned with status code " << status_code << "\n";

        return;

    }



    // Read the response headers, which are terminated by a blank line.

    boost::asio::read_until(socket, response, "\r\n\r\n");



    // Process the response headers.

    std::string header;

    while (std::getline(response_stream, header) && header != "\r")

        std::cout << header << "\n";

    std::cout << "\n";



    // Write whatever content we already have to output.

    if (response.size() > 0)

        std::cout << &response;



    // Read until EOF, writing data to output as we go.

    boost::system::error_code error;

    while (boost::asio::read(socket, response, boost::asio::transfer_at_least(1), error))

        std::cout << &response;

    if (error != boost::asio::error::eof)

        throw boost::system::system_error(error);

} 

catch (std::exception &e) 

{

    std::cout << "Exception: " << e.what() << "\n";

}





}



} // namespace ndn

} // namespace ns3



