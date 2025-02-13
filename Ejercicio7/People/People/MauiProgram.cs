﻿using Microsoft.Extensions.Logging;

namespace People;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        // Configurar la base de datos SQLite
        string dbPath = FileAccessHelper.GetLocalFilePath("people.db3");
        builder.Services.AddSingleton<PersonRepository>(s => new PersonRepository(dbPath));


        // TODO: Add statements for adding PersonRepository as a singleton

        return builder.Build();
	}
}
