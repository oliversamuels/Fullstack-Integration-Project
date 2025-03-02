# InventoryHub

## How Copilot Contributed to the Project.
### Caching Strategy: 
Copilot help ensured that the /api/productlist endpoint uses in-memory caching to store the product list for 5 minutes, reducing the need to regenerate the list on every request.

### Code Refactoring: 
Moved the product list creation logic into a separate method GetProductList(), making the code more modular and easier to maintain.

### Error Handling:
Copilot contributed to this project by enhancing the error handling in the FetchProducts.razor file. Specifically, suggested improvements to the OnInitializedAsync method to handle different types of exceptions (HttpRequestException, TaskCanceledException, and general Exception) and set appropriate error messages. This ensures that users receive meaningful feedback when there are issues fetching the product data.

### Code Refactoring:
Finally, it helped refactor the code to reduce repetition by introducing a HandleError method to handle setting the error message and logging the exception, making the OnInitializedAsync method cleaner and more maintainable.

These changes help improve the performance and readability of the code.

## Challenges
### Inability to make an Http Call:
I was unable to make an http request from the frontend to the backend at the earliest stage of the project. Neither was I able to make an Http request using RESTClient. I kept getting server not available error, even though it was accessible on the browser. Couldnt figure what was wrong. So I resulted into starting the backend project afresh.