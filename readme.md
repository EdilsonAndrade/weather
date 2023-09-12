![alt text](https://github.com/EdilsonAndrade/weather/blob/main/weatherapp.png)

# Steps to run Web Api and React

### Clone this repository

```
git clone git@github.com:EdilsonAndrade/weather.git
```

### After clone, a folder with name weather must exist into your current path

- Enter into each folder (split terminal to be easier)
- in the folder weather_api run the following command

```
dotnet run
```

### Important, verify which port it´s running

You can do a test getting the url showed in the previous command
and adding /swagger i.e

```
http://localhost:5014/swagger
```

in swagger you can click on `try it out` and paste in the required field a valid USA address like `3490 Canvas Street Kissimmee FL`

You should see a result

---

## Running React APP

### Open the folder `weather_web`

- Create a file with name `.env` in the `weather_web` folder
- Add a key with name `REACT_APP_WEB_API_URL=`
- Paste the URL exactly like this (change YOUR_PORT with the port from the web.api)
  `http://localhost:YOUT_PORT/WeatherForecast`

- Type the following command

```javascript
npm i
```

or

```javascript
yarn start
```

```javascript
npm start
```

or

```javascript
yarn start
```
