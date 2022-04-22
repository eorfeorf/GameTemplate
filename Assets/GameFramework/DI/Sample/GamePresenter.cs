using GameFramework.DI;

public class GamePresenter
{
    readonly HelloWorldService helloWorldService;

    public GamePresenter(IContainerBuilder containerBuilder)
    {
        this.helloWorldService = containerBuilder.Resolve<HelloWorldService>();
    }

    public void Draw()
    {
        helloWorldService.Hello();
    }
}
