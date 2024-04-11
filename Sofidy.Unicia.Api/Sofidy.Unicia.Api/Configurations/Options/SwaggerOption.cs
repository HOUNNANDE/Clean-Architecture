namespace Sofidy.Unicia.Api.Configurations.Options
{ 
    public record SwaggerOption
    {
        public const string Name = "Swagger";

        public bool UseSwagger { get; set; } = false;
        public string RouteTemplate { get; set; }
        public bool SerializeAsV2 { get; set; } = false;
        public SwaggerUI SwaggerUI { get; set; } = new SwaggerUI();
    }

    public record SwaggerUI
    {
        public List<Endpoint> Endpoints { get; set; } = new List<Endpoint>();
    }

    public record Endpoint
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
