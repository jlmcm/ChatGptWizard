﻿using ChatGptWizard.Service;
using ChatGptWizard.Service.IService;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace ChatGptWizard;

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
			});
		builder.Services.AddDbContext<AppDbContext>();
        builder.Services.AddScoped<IExternalLibraryService, ExternalLibraryService>();
        builder.Services.AddScoped<IPromptService, PromptService>();

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddMudServices();


#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

