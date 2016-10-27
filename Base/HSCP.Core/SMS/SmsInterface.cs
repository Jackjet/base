//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：短信发送接口
//数据表(Tables)：   
//作者(Author)： Xrp
//日期(Create Date)： 2016‎.‎06‎.27
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Configuration;
using RabbitMQ.Client;

namespace Conan.Core
{
    /// <summary>
    /// 短信发送接口
    /// </summary>
    public class MessageInterface
    {
        /// <summary>  
        /// 创建POST方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="sms">传入参数</param>  
        /// <returns></returns>  
        public static bool SmsSend(string receiver, string templateName, Dictionary<string, string> keyVals)
        {
            try
            {
                //Channel rpcChannel = new Channel(ConfigurationManager.AppSettings["GrpcUrl"], ChannelCredentials.Insecure);
                //var rpcClient = new MessageService.MessageServiceClient(rpcChannel);

                //SmsRequest request = new SmsRequest() { TplName = templateName, Receiver = receiver };
                //foreach (var kv in keyVals)
                //    request.Keyval.Add(kv.Key, kv.Value);

                //Metadata md = new Metadata();
                //md.Add(new Metadata.Entry("Authorization", "Bearer asdfghjklpoiuytrewq"));
                //var r = rpcClient.SmsMsgSend(request, md);
                //return r.Status == 1;

                SmsMsg wx = new SmsMsg() { Keyvals = keyVals, TplName = templateName, Receiver = receiver };
                AddToMq(JsonHelper.SerializeObject(wx), "sms");
                return true;
            }
            catch (Exception exp)
            {
                NLogger.Error(exp.ToString(), "短信接口");
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="templateName"></param>
        /// <param name="url"></param>
        /// <param name="title"></param>
        /// <param name="keyVals"></param>
        /// <returns></returns>
        public static bool WxMsgSend(string receiver, string templateName, string url, string title, Dictionary<string, string> keyVals)
        {
            try
            {
                //Channel rpcChannel = new Channel(ConfigurationManager.AppSettings["GrpcUrl"], ChannelCredentials.Insecure);
                //var rpcClient = new MessageService.MessageServiceClient(rpcChannel);
                //WxRequest request = new WxRequest() { TplName = templateName, Url = url, Title = title, Receiver = receiver };
                //foreach (var kv in keyVals)
                //    request.Keyval.Add(kv.Key, kv.Value);
                //Metadata md = new Metadata();
                //md.Add(new Metadata.Entry("Authorization", "Bearer asdfghjklpoiuytrewq"));
                //var r = rpcClient.WxMsgSend(request, md);

                WxMsg wx = new WxMsg() { Keyvals = keyVals, TplName = templateName, Url = url, Title = title, Receiver = receiver };
                AddToMq(JsonHelper.SerializeObject(wx), "wx");
                return true;
            }
            catch (Exception exp)
            {
                NLogger.Error(exp.ToString(), "微信信息接口");
                return false;
            }
        }



        private static void AddToMq(string message, string tag)
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = ConfigurationManager.AppSettings["Rabbit_HostName"],
                VirtualHost = ConfigurationManager.AppSettings["Rabbit_VirtualHost"],
                UserName = ConfigurationManager.AppSettings["Rabbit_UserName"],
                Password = ConfigurationManager.AppSettings["Rabbit_Password"]
            };

            string exchangeName = "message";
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    try
                    {
                        channel.ExchangeDeclare(exchangeName, "fanout");
                        channel.QueueDeclare(queue: "msg", durable: true, exclusive: false, autoDelete: false, arguments: null);
                        //var properties = channel.CreateBasicProperties();
                        //properties.Persistent = true;
                        var body = Encoding.UTF8.GetBytes(message);
                        channel.BasicPublish(exchange: exchangeName, routingKey: tag + ".message", basicProperties: null, body: body);
                        //Console.WriteLine($"{tag} {message}");
                        NLogger.Info($"{tag} {message}", "添加到rabbitmq");
                    }
                    catch (Exception exc)
                    {
                        NLogger.Debug($"{tag}{exc.Message}", "添加到rabbitmq");
                        Console.WriteLine($"{tag}{exc.Message}");
                    }
                }
            }
        }



        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="receivers"></param>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public static bool CancelOrderWxMsg(List<string> receivers, string orderNo, string StartTime, string Address)
        {
            if (receivers.Count == 0)
            {
                NLogger.Error("没有找到微信企业号", "取消订单(" + orderNo + ")");
                return false;
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("BillNo", orderNo);
            dic.Add("StartTime", StartTime);
            dic.Add("Address", Address);
            return WxMsgSend(string.Join("|", receivers), "取消订单", "http://" + ConfigurationManager.AppSettings["ygDomain"] + "/order/Detail?BillNo=" + orderNo, "取消订单", dic);
        }

        /// <summary>
        /// 派单
        /// </summary>
        /// <param name="receivers"></param>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public static bool DispatchWxMsg(List<string> receivers, string orderNo, string StartTime, string Address)
        {
            if (receivers.Count == 0)
            {
                NLogger.Error("没有找到微信企业号", "派单待确认(" + orderNo + ")");
                return false;
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("BillNo", orderNo);
            dic.Add("StartTime", StartTime);
            dic.Add("Address", Address);

            return WxMsgSend(string.Join("|", receivers), "派单待确认", "http://" + ConfigurationManager.AppSettings["ygDomain"] + "/order/Detail?BillNo=" + orderNo, "派单待确认", dic);
        }
    }


    public class SMSReult
    {
        public int State { get; set; }
        public string Msg { get; set; }
    }
}