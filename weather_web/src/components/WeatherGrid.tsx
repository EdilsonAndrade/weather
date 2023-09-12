import { ArrowRight } from "react-feather";
import { WeatherByDay } from "../types";
export const WeatherGrid: React.FC<{ weatherByDay: WeatherByDay[] }> = ({
  weatherByDay,
}: {
  weatherByDay: WeatherByDay[];
}) => {
  return (
    <div className="grid mobile:grid-cols-4 desktop:grid-cols-7 gap- mt-2">
      {!!weatherByDay.length &&
        weatherByDay.map((weatherByDay: WeatherByDay) => {
          const startWeather = weatherByDay.forecasts[0];
          const endWeather = weatherByDay.forecasts[1];
          const startDate = new Date(startWeather.startTime);
          const endDate = new Date(endWeather.startTime);
          const startHour = `${startDate.getHours()}am`;
          const endHour = `${endDate.getHours()}pm`;
          const day = weatherByDay.day;
          return (
            <div
              key={weatherByDay.day}
              className="flex flex-col items-center justify-start border-gray-50 rounded-md p-1 border"
            >
              <div className="flex flex-col items-center justify-start ">
                <span className="text-sm font-bold">{day}</span>
                <small className="text-xs">{`${startHour} - ${endHour}`}</small>
              </div>
              <img
                src={startWeather.icon}
                alt={startWeather.name}
                className="rounded-sm"
              />
              <div className="flex justify-between items-center p-1">
                <div className="flex items-center justify-center text-sm font-bold mr-1">
                  <span>{startWeather.temperature}</span>
                  <span>{startWeather.temperatureUnit}</span>
                </div>
                <ArrowRight size={16} />
                <div className="flex items-center justify-center text-sm font-bold">
                  <span>{endWeather.temperature}</span>
                  <span>{endWeather.temperatureUnit}</span>
                </div>
              </div>
              <span className="text-xs">{startWeather.shortForecast}</span>
            </div>
          );
        })}
    </div>
  );
};
