namespace TodoApi.Todos;

internal static class TodoApi
{
    public static RouteGroupBuilder MapTodos(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/todos");

        return group;
    }
}