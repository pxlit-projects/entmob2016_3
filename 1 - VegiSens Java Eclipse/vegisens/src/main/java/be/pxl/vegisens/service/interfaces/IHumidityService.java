package be.pxl.vegisens.service.interfaces;

import be.pxl.vegisens.domain.Humidity;

public interface IHumidityService 
{
	Humidity addHumidity(Humidity humidityToAdd);
	Humidity updateHumidity(Humidity humidityToUpdate);
}
