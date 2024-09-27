# Candidate Interview - Test
## Background 
One trainee has done a tool internally and now the needs for this tools will grow.
This tools only allows our worldwide company, food inc, to share some list of product between severals users.

Your chief have made a quick check, and in order to allow this tool to grow, we have to consolidate what has been done by the traine.

## Your mission:
In the next 4 hours, you have to get the current version of the code(located at https://github.com/jaytonic/CandidatesInterview), import it in your own github repository(**Make sure that you make an initial commit without changing the code**), clean and fix it. The goal is that you do the more you can in this timespan.
After the 4hours, commit and send us back the link to your repository(**Important: Do not fork it as this will provide your work to the other candidates**).

The users currently having this tools are reporting the following issues:
* When the user add items to the list, the GUI seems to be frozen until the item is appearing in the list
* When more than one people use the application at the same time it crash(there is a simulator that simulate another user after 20 seconds ), the list doesn't update
* The application doesn't resize well
 
Your chief, after his brief investigation, ask you to fix and refactor the code, including:
 - Refactor of the code to match best pratices(WPF and architecture)
 - Refactor the application to be able to add other kind of products in the future without having to change the GUI
 - Make sure that the current code is optimized
 - Provide a result that you think is representative of what you think is a good code
 
 
 
## Note:
* The simulator(RemoteProductWorkerSimulator) is out of scope and should not be changed
* The Thread.Sleep should not be removed, they simulate some latency due to the data layer
* The convention in the company are the one advised by microsoft Guidelines
* You can also find the requirement [here](Prerequisite.md)
