package be.pxl.vegisens.application;

public interface IHumidityService 
{
	Humidity addHumidity(Humidity humidityToAdd);
	Humidity updateHumidity(Humidity humidityToUpdate);
}
