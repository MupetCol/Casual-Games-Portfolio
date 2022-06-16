using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class StacksAndQueues : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Stacks and Queues are generics type collections
        // Queues tend to be used when order matters, like in fighting games combos
        // or server requests queueing
        Stack<int> stack = new Stack<int>();
        Queue<int> queue = new Queue<int>();

        //STACK
        // Add elements to the stack using Push()
        // Get the top item with Peek()
        // Get and Delete the top item using Pop()

        Debug.Log("STACK");
        stack.Push(1);
        Debug.Log("Top value in the stack is " +  stack.Peek());
        stack.Push(2);
        Debug.Log("Top value in the stack is " + stack.Peek());
        stack.Push(3);
        Debug.Log("Top value in the stack is " + stack.Peek());
        stack.Pop();
        Debug.Log("Top value in the stack is " + stack.Peek());

        // QUEUE
        // Add elements to the queue using Enqueue()

        queue.Enqueue(1);
        Debug.Log("QUEUE");
        Debug.Log("Top value in the queue is " + queue.Peek());
        queue.Enqueue(2);
        Debug.Log("Top value in the queue is " + queue.Peek());
        queue.Enqueue(3);
        Debug.Log("Top value in the queue is " + queue.Peek());



        while (stack.Count > 0)
        {
            Debug.Log("The top value " + stack.Pop() + " was removed, count is now " + stack.Count);
        }

        Queue<Order> ordersQueue = new Queue<Order>();

        foreach(Order order in ReceiveOrdersFromBranch1())
        {
            ordersQueue.Enqueue(order);
        }

        foreach (Order order in ReceiveOrdersFromBranch2())
        {
            ordersQueue.Enqueue(order);
        }

        while(ordersQueue.Count > 0)
        {
            Order currentOrder = ordersQueue.Dequeue();
            currentOrder.ProcessOrder();
        }



    }


    void ReversingArraysWithStack()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8 };
        Stack<int> reverseStack = new Stack<int>();

        // Pushing the numbers into the stack
        foreach (int number in numbers)
        {
            reverseStack.Push(number);
        }

        // Poping them out in reverse due to how stack works
        foreach (int number in numbers)
        {
            reverseStack.Pop();
            // Get numbers here
        }
    }

    Order[] ReceiveOrdersFromBranch1()
    {
        Order[] orders = new Order[]
        {
            new Order(1,5),
            new Order(2,6),
            new Order(6,7)
        };
        return orders;
    }

    Order[] ReceiveOrdersFromBranch2()
    {
        Order[] orders = new Order[]
        {
            new Order(3,5),
            new Order(4,6),
            new Order(5,7)
        };
        return orders;
    }

}

class Order
{
    //order ID
    public int OrderId { get; set; }
    public int OrderQuantity { get; set; }

    public Order(int id, int OrderQuantity)
    {
        this.OrderId = id;
        this.OrderQuantity = OrderQuantity;
    }

    public void ProcessOrder()
    {
        Console.WriteLine($"Order {OrderId} processed.");
    }
}
