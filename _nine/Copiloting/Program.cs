using Copiloting.diagnosing;

Console.WriteLine("Hello, Copiloting!");

new Buggy().LogicIssue();

/*
 1. exception:
 the application crashes when I remove item from goodies list. It then show the following stack dump: <copy stack trace>

and Send to GitHub Copilot for analysis.

    2. logical error:
    The program says item b is removed but I expect item a is removed. Can you diagnose what has caused this and try to fix this?
 */