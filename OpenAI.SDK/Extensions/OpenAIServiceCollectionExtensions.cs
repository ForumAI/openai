﻿using Microsoft.Extensions.DependencyInjection;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.Managers;

namespace OpenAI.GPT3.Extensions;

public static class OpenAIServiceCollectionExtensions
{
    public static IHttpClientBuilder AddOpenAIService(this IServiceCollection services, Action<OpenAiOptions>? setupAction = null)
    {
        var optionsBuilder = services.AddOptions<OpenAiOptions>();
        if (setupAction != null)
        {
            optionsBuilder.Configure(setupAction);
        }
        else
        {
            optionsBuilder.BindConfiguration(OpenAiOptions.SettingKey);
        }

        return services.AddHttpClient<IOpenAIService, OpenAIService>();
    }
}