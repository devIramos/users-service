// <summary>
// <copyright file="SampleBackground.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.API.Backgrounds
{
    /// <summary>
    /// Class SampleBackground.
    /// </summary>
    public class SampleBackground : BackgroundService
    {
        private readonly ILogger<SampleBackground> logger;
        private readonly IKafka kafka;

        /// <summary>
        /// Initializes a new instance of the <see cref="SampleBackground"/> class.
        /// </summary>
        /// <param name="logger">Object <see cref="ILogger{SampleBackground}"/>.</param>
        /// <param name="kafka">Object Kafka.</param>
        public SampleBackground(
            ILogger<SampleBackground> logger,
            IKafka kafka)
        {
            this.logger = logger;
            this.kafka = kafka;
        }

        /// <inheritdoc/>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            this.logger.LogDebug($"Example kafka background is starting.");

            stoppingToken.Register(() =>
                this.logger.LogDebug($"Example kafka background task is stopping."));

            await Task.Delay(1000, stoppingToken);

            await this.ProcessExecuteAsync(stoppingToken);
        }

        private async Task ProcessExecuteAsync(CancellationToken stoppingToken)
        {
            using var consumer = this.kafka.BuildConsumer("ExampleKafka", nameof(UserMessagesDto));
            while (!stoppingToken.IsCancellationRequested)
            {
                this.logger.LogDebug("Example kafka task doing background work.");
                try
                {
                    var consumeResult = this.kafka.Consume(consumer, stoppingToken);
                    if (consumeResult == null)
                    {
                        await Task.Delay(1000, stoppingToken);
                        continue;
                    }

                    consumer.Commit(consumeResult);
                    UserMessagesDto project =
                        JsonConvert.DeserializeObject<UserMessagesDto>(consumeResult.Message.Value);
                    this.logger.LogDebug("Mensaje obtenido: {Message}.", project.Message);
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, "{Message}", ex.Message);
                }
            }

            consumer.Close();
        }
    }
}
