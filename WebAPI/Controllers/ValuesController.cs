using System.Messaging;
using System.Web.Http;


namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        string path = @".\Private$\WebKeyboard1";
        MessageQueue msgQ;
        public ValuesController()
            : base()
        {
            if (!MessageQueue.Exists(path))
                MessageQueue.Create(path);
            msgQ = new MessageQueue(path);

        }


        NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void Get(int id)
        {
            msgQ.Send(id, "One");
        }

        public void Get(int id, bool shift, bool ctrl, bool alt)
        {
            ///TODO
        }


        // POST api/values
        public void Post([FromBody]string value)
        {
        }
    }
}