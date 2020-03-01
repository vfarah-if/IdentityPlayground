# Introduction﻿

Basics is about introducing the basics of ASP .net Core 3.(n) and simple authentication. This is an empty project where default controllers are setup with views and authorization is slowly configured to show a page you can or can't see. Track history to understands what has changed to get to the end result.

## Summary of learning steps

1. Create empty project and then add *startup* to work with default MVC setup
2. Setup views to be part of the service
3. Create Controllers Folder and create *HomeController* as default controller
4. Create Authorized secret page, default page open to everyone and a way of registering
5. Create views that represent the view in question and see fix all respective expectation issues
6. Linkup cookie authentication
7. Refactor Authorise to sign in with claims, identities and principle and this will allow an authorised page to be viewed
8. *UseAuthentication* should be done first to set identity and *UseAuthorization* should then verify what you are authorized to view
9. Added a commented out example of showing how one can work with claims and the policy builder. 
10. Create custom claim handler and custom claim and showed how to inject this as a service for common use with entire solution
11. Show how to retro fit roles, a legacy concept that should be avoided, utilise it as a claim

View cookie generated and view page being opened once the sign occurs. Basic scenario shows simple authorization model in very few steps.