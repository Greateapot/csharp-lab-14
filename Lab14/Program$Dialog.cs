using ConsoleDialogLib;
using Lab10Lib.Entities;
using Lab12Lib.BinaryTree;

namespace Lab14
{
    public static partial class Program
    {
        private static ConsoleDialog MainDialog() => new(
            Messages.MainDialogTitle,
            [
                new(Messages.MainDialogOption1, _ => Task1Dialog().Show()),
                new(Messages.MainDialogOption2, _ => Task2Dialog().Show()),
            ]
        );

        private static ConsoleDialog Task1Dialog() => new(
            () => string.Format(Messages.Task1DialogTitle, Utils.PrintCity(InstanceHolder.Get<Stack<Dictionary<Person, Person>>>())),
            [
                new(Messages.Task1DialogOption1, _ => Task1Option1Process(), pauseAfterExecuted: true),
                new(Messages.Task1DialogOption2, _ => Task1Option2Process(), pauseAfterExecuted: true),
                new(Messages.Task1DialogOption3, _ => Task1Option3Process(), pauseAfterExecuted: true),
                new(Messages.Task1DialogOption4, _ => Task1Option4Process(), pauseAfterExecuted: true),
                new(Messages.Task1DialogOption5, _ => Task1Option5Process(), pauseAfterExecuted: true),
            ]
        );

        private static ConsoleDialog Task2Dialog() => new(
            () => string.Format(Messages.Task2DialogTitle, InstanceHolder.Get<BinaryTree<Person>>().ToString()),
            [
                new(Messages.Task2DialogOption1, _ => Task2Option1Process(), pauseAfterExecuted: true),
                new(Messages.Task2DialogOption2, _ => Task2Option2Process(), pauseAfterExecuted: true),
                new(Messages.Task2DialogOption3, _ => Task2Option3Process(), pauseAfterExecuted: true),
            ]
        );


        private static bool InputBoolean(string title) => (bool)ConsoleDialog.ShowDialog(new(
            title,
            [
                new(Messages.BooleanDialogYes, _ => true, true, false, true),
                new(Messages.BooleanDialogNo, _ => false, true, false, true),
            ],
            false,
            true,
            false
        ))!;
    }
}