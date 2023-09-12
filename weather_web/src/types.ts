export interface WeatherByDay {
  day: string;
  forecasts: Forecast[];
}
export interface Forecast {
  number: number;
  name: string;
  temperature: number;
  temperatureUnit: string;
  windSpeed: string;
  windDirection: string;
  icon: string;
  shortForecast: string;
  detailedForecast: string;
  startTime: Date;
}

export interface HttpResponse {
  statusCode: number;
  body: any;
}
