using Microsoft.SemanticKernel;

namespace _02_05b
{
    public static class TrySK
    {
        public static async Task Execute()
        {
            var modelDeploymentName = "gpt-4.1";
            var azureOpenAIEndpoint = Environment.GetEnvironmentVariable("AZUREOPENAI_ENDPOINT");
            var azureOpenAIKey = Environment.GetEnvironmentVariable("AZUREOPENAI_APIKEY");
            var builder = Kernel.CreateBuilder()
                .AddAzureOpenAIChatCompletion(
                    modelDeploymentName,
                    azureOpenAIEndpoint,
                    azureOpenAIKey
                );
            var kernel = builder.Build();
            var topic = "AI";
            var prompt = "What are the latest trends in AI?";
            var poem = await kernel.InvokePromptAsync(prompt);
            Console.WriteLine($"Prompt: {prompt}");
            Console.WriteLine($"Response: {poem}");
        }
    }
}
