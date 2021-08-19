using System;

namespace InitiatorFix
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine(  "=============\n" +
                                "INITIATOR\n" + 
                                "=============");

            try
            {
                QuickFix.SessionSettings settings = new QuickFix.SessionSettings("../../../tradeclient.cfg");
                TradeClientApp application = new TradeClientApp();
                QuickFix.IMessageStoreFactory storeFactory = new QuickFix.FileStoreFactory(settings);
                QuickFix.ILogFactory logFactory = new QuickFix.ScreenLogFactory(settings);
                QuickFix.Transport.SocketInitiator initiator = new QuickFix.Transport.SocketInitiator(application, storeFactory, settings, logFactory);

                application.MyInitiator = initiator;

                initiator.Start();
                application.Run();
                initiator.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            Environment.Exit(1);

        }
    }
}
