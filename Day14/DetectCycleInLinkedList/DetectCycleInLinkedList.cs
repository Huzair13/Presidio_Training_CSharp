namespace DetectCycleInLinkedList
{
    public class Node
    {
        public int value;
        public Node next;

        public Node(int value)
        {
            this.value = value;
            this.next = null;
        }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;
        public int length;

        public LinkedList(int value)
        {
            Node newNode = new Node(value);
            head = newNode;
            tail= newNode;
            length = 1;
        }

        public async Task AppendLLNode(int value)
        {
            Node newNode = new Node(value);
            if(length==0)
            {
                head= newNode;
                tail= newNode;
            }
            else 
            {
                tail.next = newNode;
                tail = newNode;
                length++;
            }
        }

        public async Task<bool> detectCycle()
        {
            Node slow = head;
            Node fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                {
                    return true;
                }
            }
            return false;
        }
    }


    public class Program
    {
        static async Task Main(string[] args)
        {
            //SAMPLE INPUT 0
            LinkedList myLL = new LinkedList(3);
            await myLL.AppendLLNode(2);
            await myLL.AppendLLNode(0);
            await myLL.AppendLLNode(0);
            await myLL.AppendLLNode(4);

            myLL.tail.next = myLL.head.next;


            //SAMPLE INPUT 1
            //LinkedList myLL = new LinkedList(1);
            //myLL.AppendLLNode(2);
            //myLL.tail.next = myLL.head.next;

            //SAMPLE INPUT 2
            //LinkedList myLL = new LinkedList(3);
            //myLL.AppendLLNode(2);
            //myLL.AppendLLNode(0);
            //myLL.AppendLLNode(0);
            //myLL.AppendLLNode(4);

            bool result = myLL.detectCycle().Result;
            if (result)
            {
                Console.WriteLine("Cycle is Detected");
            }
            else
            {
                Console.WriteLine("Cycle is not detected");
            }
        }
    }
}
