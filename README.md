# Ferienplanner

## Project Setup

### Connect with Database
Open `appsettings.json`
> ./Backend/VacationPlannerDataAPI/VacationPlannerDataAPI/VacationPlannerDataAPI/appsettings.json
>
In the third Line is the Property `VacationPlanner` with the value `Data Source = [PC-NAME];Initial Catalog=VacationPlanner;Trusted_Connection=True`.<br />
Remove the brackets and type your PC Name in.

### Frontend Setup
Too start the Frontend, you'll need to install the packages.<br />
Start your Terminal in the <i>Ferienplanner folder:</i>
> cd ./Ferienplanner
>
and install the packages:
>
> npm install

### Compile and Hot-Reload for Development
> npm run dev

### Type-Check, Compile and Minify for Production
> npm run build