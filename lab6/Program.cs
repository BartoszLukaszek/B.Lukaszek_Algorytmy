namespace lab6
{
internal class Program
{
    static void Main(string[] args)
    {

        Stack<int> stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        Console.WriteLine(stack.Count == 3);
        Console.WriteLine(stack.Pop() == 6);
        string expression ="2 5 + 7 * 4 2 - /";
        foreach(string token in expression.Split(","))
        {
            switch(token)
            {
                case "+":
                    stack.Push(stack.Pop() + stack.Pop());
                    break;
                case "-":
                    stack.Push(stack.Pop() - stack.Pop());
                    break;
                case "*":
                    stack.Push(stack.Pop() * stack.Pop());
                    break;
                case "/":
                    stack.Push(stack.Pop() / stack.Pop());
                    break;
                default:
                    if (int.TryParse(token, out int value))
                    {
                        stack.Push(value);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid token");
                    }
                    break;
            }
        }

        }
}
internal class Node<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; set; }
}
public class LinkedSrack<T> 
{
    private Node<T> head;
    private Node<T> tail;
    private int count;
    public int Count
    {
        get { return count; }
    }

    public void Enqueue (T item)
    {
        if (IsEmpty())
        {
            head = new Node<T> { Value = item };
            tail = head;
        }
        else
        {
            var node = new Node<T> { Value = item };
            tail.Next = node;
            tail = node;
        }   
        count++;
    }

    public T Dequeue()
    {
        if (IsEmpty())
        {
            T result = head.Value;
            head = head.Next;
            count--;
            return result;
        }
        else
        {
            throw new InvalidOperationException("Stack is empty");
        }
        
    }
private Node<T> head;

 public void Push(T item)
 {
        var node = new Node<T> { Value = item };
        node.Next = head;
        head = node;
        count++;

 }

 public T Pop()
 {
    throw new NotImplementedException();
 }

 }

} 
