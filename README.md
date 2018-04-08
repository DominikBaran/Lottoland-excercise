# Project Title

Lottoland - example test automation for the user registration

## Getting Started

Project developed in C#/.net (4.6) using Visual Studio 2015.
Solution use:
- Nunit version 3.10.x
- Selenium WebDriver - 3.11.x
- Selenium WebDriver Support - 3.11.x
- Selenium.Chrome.WebDriver.2.37
- Selenium.Firefox.WebDriver.0.20.0

For the project and the automation I used two main test automation approaches:
- Page Object pattern
- Page Object factory

Because of lack of time I did not use Behavior Driven Development (BDD) approach
with feature (gherkin) files and Given/When/Then descriptive language. However
solution is created in really general and flexible way so it is not really big
problem to update solution to use BDD approach.
What is more all the helpers and generators are generic: for the test approach
we will select 5 users from list of 10 - but the method accept argument so it's
possible to select 1-max number of the users.

There is also possible to change testing url and browser - in App.config file in
the solution. Test automation supports 2 of the most common usage browsers:
Mozilla Firefox and Google Chrome.

### Prerequisites

As a prerequisite to run the test - it's important to have install c# compiler
(or Visual Studio IDE) and .net on the machine.
All the libraries needed for the test will be automatically download and install
by Nuget package - which is a part of .net/Visual studio.
After nuget package installation all needed libraries should be available in
Project folder/packages/{name of the library}


### Installing

As above - all the packages will be installed by Nuget package manager.

## Running the tests

To run test please open solution in Visual Studio 2015 (or newer), compile code
and run unit test use nunit explorer or re-sharper test explorer.
Additionally when the code is compiled (bin/Debug & bin/Release folders exist) to
run the test we could use desktop nunit runner.


## Authors

* **Dominik Baran**


## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

## Test Results example
As a result of the test execution user should be able to see something similar to:
![Alt text](/results/result.PNG "Result example")
