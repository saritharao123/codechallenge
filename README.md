 **Prerequesties to run the Project:**
 1. this asp.net web api project using .net core 3.1 framework
 2. runrun this project, clone project to local mechine
 3. open project in Visual Studio 2019 commmunity, developer or enterprise edition
 
** Functionality Implemented in this project:**
 a. **Implementation of Web API endpoins:**
   1. Implemented WebApiController.cs under the folder "\Controllers"
   2. "\Controllers\WebApiController.cs" have two enpoint point methods GET,POST
   3. GET method gets the Supervisors list from "https://609aae2c0f5a13001721bb02.mockapi.io/lightfeather/managers" and returns supervisor details 
   4. Post method accepts the input data from Client application, returning back the same result to client application (Actual functionality of insert not implemented as per the task)
b. **implementation of UI Client**
  1. implemented UI form "index.html" under "wwwroot" folder
  2. Form designed with the required fields select supervisor dropdown box (which populates list of Supervisors by consumming above web api endpoint a.3), firstName, lastName, 
     email, phone and selected supervisor input text boxes)
  3. Form validating and displays error message when submit form with in valid data
      a. firstName( required)
      b. lastName(required)
      c. email(if enter email, email formate should be <user_name>@<provider>.<domain> eg. john@gmail.com
      d. phone(if enters 10 digits minimum length)
      e. either email or phone required from both
  4. when submit form, getting all form fields data, pass that input form data to the "Post" endpoint a.4
     sample form data {"firstName":"ww","lastName":"ww","email":"john@gmail.com","phone":"1234567890","supervisor":"b-Elijah-Cremin"}

