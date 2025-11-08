using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Test enqueueing and dequeuing items with different priorities
    // Expected Result: Items should be dequeued in order of highest priority first
    // Defect(s) Found: Original implementation had three issues:
    // 1. Loop in Dequeue only went to Count-1 instead of Count
    // 2. Items weren't being removed from queue when dequeued
    // 3. >= comparison meant later items with same priority were chosen instead of earlier ones
    public void TestPriorityQueue_DifferentPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 3);
        priorityQueue.Enqueue("Medium", 2);
        
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test enqueueing multiple items with same priority
    // Expected Result: Items with same priority should be dequeued in FIFO order
    // Defect(s) Found: Original implementation used >= which caused items to be
    // dequeued in LIFO order instead of FIFO order when priorities were equal
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 2);
        priorityQueue.Enqueue("Third", 2);
        
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test dequeuing from empty queue
    // Expected Result: Should throw InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None - this functionality worked correctly in original implementation
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected exception was not thrown");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Test complex mix of priorities with some duplicates
    // Expected Result: Items should be dequeued in strict priority order,
    // with same-priority items following FIFO
    // Defect(s) Found: Multiple issues with priority handling and FIFO ordering
    public void TestPriorityQueue_ComplexMix()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 3);
        priorityQueue.Enqueue("E", 1);
        priorityQueue.Enqueue("F", 3);
        
        Assert.AreEqual("D", priorityQueue.Dequeue()); // First priority 3
        Assert.AreEqual("F", priorityQueue.Dequeue()); // Second priority 3
        Assert.AreEqual("B", priorityQueue.Dequeue()); // First priority 2
        Assert.AreEqual("C", priorityQueue.Dequeue()); // Second priority 2
        Assert.AreEqual("A", priorityQueue.Dequeue()); // First priority 1
        Assert.AreEqual("E", priorityQueue.Dequeue()); // Second priority 1
    }
}