import { useState } from "react";
import { Loader } from "react-feather";
import { WeatherGrid } from "../components/WeatherGrid";
import { HttpResponse, WeatherByDay } from "../types";

export const WeatherView: React.FC = () => {
  const [weatherByDay, setWeatherByDay] = useState<WeatherByDay[]>([]);
  const [address, setAddress] = useState<string>();
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>();

  const getWeathers = async () => {
    setError("");
    setWeatherByDay([]);
    const baseUrl = process.env.REACT_APP_WEB_API_URL;
    setLoading(true);
    const response = await fetch(`${baseUrl}?fullAddress=${address}`);
    const data = (await response.json()) as HttpResponse;

    if (data.statusCode === 200) {
      setWeatherByDay(data.body);
    } else {
      setError(data.body.message);
    }
    setLoading(false);
  };

  return (
    <div className="flex flex-col p-5 items-center justify-center ml-auto">
      <input
        type="text"
        value={address}
        onChange={(e) => setAddress(e.target.value)}
        placeholder="3490 Canvas Street Kissimmee FL"
        className="border border-gray-300 outline-none p-2 w-64"
      />
      <button
        disabled={!address?.length}
        className={`${
          !address?.length ? "cursor-not-allowed opacity-50" : " cursor-pointer"
        } border border-blue-500 bg-blue-500 py-1 px-3 rounded-md text-white font-bold mt-2`}
        onClick={getWeathers}
      >
        Get Weather
      </button>
      {loading && <Loader className="animate-spin mt-2" />}
      {weatherByDay && <WeatherGrid weatherByDay={weatherByDay} />}
      {error && <div className="text-red-500 mt-2">{error}</div>}
    </div>
  );
};
