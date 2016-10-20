package be.pxl.vegisens.application;

import java.util.List;

public interface IGrowableItemService {

	List<GrowableItem> getAllGrowableItems();
	List<Humidity> getHumidityData();
	List<Temperature> getTemperatureData();
}
