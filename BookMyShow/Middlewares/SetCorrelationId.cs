namespace BookMyShow.Middlewares
{
    public class SetCorrelationId
    {
        private readonly RequestDelegate _next;

        public SetCorrelationId(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Guid guid = Guid.NewGuid();
            context.TraceIdentifier = guid.ToString();
            await _next(context);
        }
    }
}
