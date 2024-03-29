# Todo app design document

## Summary

This simple app will allow users to create and manage a list of todos. Users should be a able to add, remove and mark todos as complete.

## Functional requirements

A user of the app should be able to create a new todo item by entering some text in a input field. After creating the todo item the user should be able to see the todo they have just created in a list.

A todo item in the list should be able to be marked as done. When a todo item is marked as done it should be visually distinct from the other todo items in the list.

A todo item that was marked as done should be able to be unmarked as done. Again when a todo item is unmarked as done it should be visually distinct from the other todo items in the list.

Todos are added in chronological order the most recent todo should be at the bottom of the list.

A user should be able to remove a todo item from the list. When a todo item is removed from the list it should no longer be visible.

## Technical limitations

The app does not need to persist data between sessions. This means that when the app is restarted all todos will be lost.

The app does not support multiple users. Every users is presented with the same list of todos.

