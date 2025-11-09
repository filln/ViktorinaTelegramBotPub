// Copyright 2021 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

//Создает объекты для соединения с телеграмом, управляет созданием и доступом к ViktorinaStarter

using Viktorina.Bot;


namespace ViktorinaTelegramBot;
public static class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
        viktorinaStarter = ViktorinaStarter.GetCurrent();
        AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
    }


    /**
     * Variables
     */
    public static HandleUpdateService? handleUpdateService;
    private static ViktorinaStarter? _viktorinaStarter;
    public static ViktorinaStarter viktorinaStarter
    {
        get
        {
            return ViktorinaStarter.GetCurrent();
        }
        private set
        {
            _viktorinaStarter = value;
        }
    }

    /**
     * Methods
     */
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

    private static void CurrentDomain_ProcessExit(object? sender, EventArgs e)
    {
        viktorinaStarter.CurrentDomain_ProcessExit();
        Console.WriteLine("CurrentDomain_ProcessExit()");
    }


}
