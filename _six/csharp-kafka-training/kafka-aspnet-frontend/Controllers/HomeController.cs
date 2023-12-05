using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using kafka_aspnet_frontend.Models;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace kafka_aspnet_frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // TODO: appsettings/dependency injection

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegistrationModel model)
        {
            // TODO: client config - hard-coded
            ClientConfig clientConfig = new ClientConfig();
            clientConfig.BootstrapServers = "your endpoint";
            clientConfig.SecurityProtocol = SecurityProtocol.SaslSsl;
            clientConfig.SaslMechanism = SaslMechanism.Plain;
            clientConfig.SaslUsername = "your key";
            clientConfig.SaslPassword = "your secret";
            clientConfig.SslCaLocation = "probe";

            // TODO: client config with appsettings/dependency injection

            // TODO: Register logic
            string topicName = "user-registration";
            string key = Guid.NewGuid().ToString();
            model.UserId = key;
            string message = JsonConvert.SerializeObject(model);
            Produce(topicName, model.UserId, message, clientConfig);

            ViewBag.Message = "User registration request is sent to the server.";
            return View(model);
        }

        // TODO: GetKafkaConfig method

        // TODO: deliveryHandler method
        void deliveryHandler(DeliveryReport<string, string> deliveryReport)
        {
            if (deliveryReport.Error.Code == ErrorCode.NoError)
            {
                Debug.WriteLine($@"\n* Message delivered to:
                ({deliveryReport.TopicPartitionOffset}) with these details: ");

                Debug.WriteLine($@"-- Key: {deliveryReport.Key},\n-- Timestamp:
                    {deliveryReport.Timestamp.UnixTimestampMs}");
            }
            else
            {
                Debug.WriteLine($@"Failed to deliver message with error: {deliveryReport.Error.Reason}");
            }
        }

        // TODO: Produce method
        void Produce(string topicName, string key, string value, ClientConfig config)
        {
            using (IProducer<string, string> producer = new
            ProducerBuilder<string, string>(config).Build())
            {
                double flushTimeSec = 7.0;
                Message<string, string> message = new Message<string, string>
                {
                    Key
                = key,
                    Value = value
                };
                producer.Produce(topicName, message, deliveryHandler);
                Debug.WriteLine($@"Produced/published message with key:
                    {message.Key} and value: {message.Value}");

                var queueSize = producer.Flush(TimeSpan.FromSeconds(flushTimeSec));
                if (queueSize > 0)
                {
                    Debug.WriteLine($@"WARNING: Producer event queue has not been
                    fully flushed after {flushTimeSec}
                    seconds; {queueSize} events pending.");
                }
            }
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult DeleteTopic()
        {

            return View("Admin");
        }
        public ActionResult CreateTopic()
        {

            return View("Admin");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
