#### TextFileProcessor is a code challenge to process a text file and find out the most frequent word then modify the word and represnt the text again.

The solution is an ASP.NET Core project with simple React as client App. 
There are 4 main projects:
- Data project: this project is responsible for the dbcontext of the solution
- Core project: to apply best practice and data layers architecture this is where all the service should exist.
- API project: this is made to be able to post the file via an api or post information about the processed text to be stored in the databse.
- WEB project: is the client app and it's a simple react app with help from bootstrap.
