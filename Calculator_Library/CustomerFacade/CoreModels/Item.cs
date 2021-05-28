namespace Calculator.CustomerFacade.CoreModels
{
    public class Item
    {
        
         public string[] Symbol { get; private set; } = new[] { "*(", "+(", "-(", "/(", ")*", ")/", ")+", ")-", "-", "+", "/", "*", ")", "(", " (", ") ", "," };
            
    }
}
