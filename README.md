# Test Automation for Swag Labs

## Launch URL  
**[Swag Labs](https://www.saucedemo.com/)**  

---

## Test Cases  

### **UC-1: Test Login form with empty credentials**  
1. Type any credentials into "Username" and "Password" fields.  
2. Clear the inputs.  
3. Hit the "Login" button.  
4. Check the error message: **"Username is required"**.  

### **UC-2: Test Login form with credentials by passing Username**  
1. Type any credentials in the "Username" field.  
2. Enter a password.  
3. Clear the "Password" input.  
4. Hit the "Login" button.  
5. Check the error message: **"Password is required"**.  

### **UC-3: Test Login form with credentials by passing Username & Password**  
1. Type credentials in the "Username" field that are listed under the accepted usernames section.  
2. Enter **"secret_sauce"** as the password.  
3. Click on the "Login" button.  
4. Validate that the dashboard title is **"Swag Labs"**.  


Provide parallel execution, add logging for tests and use Data Provider to parametrize tests. Make sure that all tasks are supported by these 3 conditions: UC-1; UC-2; UC-3.
