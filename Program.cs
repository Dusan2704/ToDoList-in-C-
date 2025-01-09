
var todos = new List<string>();



Console.WriteLine("Hello!");
bool shallExit = false;
while (!shallExit)
{
    Console.WriteLine("[S]ee all TODOs!");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
    var userChoice = Console.ReadLine();

    switch (userChoice)
    {
        case "S":
        case "s":
            PrintSelectedOption("See all TODOs");
            SeeAllTodos();
            break;

        case "A":
        case "a":
            PrintSelectedOption("Add a TODO");
            AddTodo();
            break;

        case "R":
        case "r":
            PrintSelectedOption("Remove a TODO");
            RemoveTodo();
            break;

        case "E":
        case "e":
            PrintSelectedOption("Exit");
            shallExit = true;
            break;

        default:
            Console.WriteLine("Invalid choice");
            break;
    }
}



Console.ReadKey();

void SeeAllTodos()
{
    if (todos.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }
    for (int i = 0; i < todos.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todos[i]}");
    }

}

void AddTodo()
{
    string description;
    do
    {
        Console.WriteLine("Enter the TODO description");
        description = Console.ReadLine();





    }
    while (!IsDescriptionValid(description));
    todos.Add(description);
}

bool IsDescriptionValid(string description)
{
    if (description == "")
    {
        Console.WriteLine("The description cannot be empty");
        return false;
    }
    if (todos.Contains(description))
    {
        Console.WriteLine("The description must be unique. ");
        return false;
    }
    return true;
}


void RemoveTodo()
{
    if (todos.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }
    bool isIndexValid = false;
    while (!isIndexValid)
    {
        Console.WriteLine("Select the index of the TODO you want to remove");
        SeeAllTodos();
        var userInput = Console.ReadLine();
        if (userInput == "")
        {
            Console.WriteLine("Selected index cannot be empty");
            continue;
        }
        if (int.TryParse(userInput, out int index) &&
            index >= 1 &&
            index <= todos.Count)
        {
            var indexOfTodo = index - 1;
            var todoToBeRemoved = todos[indexOfTodo];
            todos.RemoveAt(indexOfTodo);
            isIndexValid = true;
            Console.WriteLine("TODO removed: " + todoToBeRemoved);
        }
        else { Console.WriteLine("The given index is not valid"); }
    }
}
void PrintSelectedOption(string selectedOption)
{
    Console.WriteLine("Selected option: " + selectedOption);
}
static void ShowNoTodosMessage()
{
    Console.WriteLine("No TODOs have been added yet.");
}









