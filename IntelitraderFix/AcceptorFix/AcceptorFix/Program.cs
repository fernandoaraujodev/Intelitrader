using QuickFix;
using System;

namespace AcceptorFix
{
    class Program
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [STAThread]
        static void Main(string[] args)
        {

            Console.WriteLine(  "=============\n" +
                                "ACCEPTOR\n" +
                                "TargetCompID = 'SIMPLE' and SenderCompID = 'CLIENT1' or 'CLIENT2'\n" +
                                "Port 5001\n" +
                                "=============" );

            try
            {
                SessionSettings settings = new SessionSettings("../../../sample_acceptor.cfg");
                IApplication app = new Acceptor();
                IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
                ILogFactory logFactory = new FileLogFactory(settings);
                IAcceptor acceptor = new ThreadedSocketAcceptor(app, storeFactory, settings, logFactory);

                acceptor.Start();
                Console.WriteLine("press <enter> to quit");
                Console.Read();
                acceptor.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine("==FATAL ERROR==");
                Console.WriteLine(e.ToString());
            }



        }
    }
}
