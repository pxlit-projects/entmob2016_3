package be.pxl.vegisens.application;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional
public class GrowableItemServiceImpl implements IGrowableItemService
{
	@Autowired
	private GrowableItemRepository repository;

	@Autowired
	private TemperatureRepository tempRepository;
	
	@Autowired
	private HumidityRepository humRepository;
	
	public List<GrowableItem> getAllGrowableItems() 
	{
		return (List<GrowableItem>) repository.findAll();
	}

	public List<Humidity> getHumidityData()
	{
		return (List<Humidity>) humRepository.findAll();
	}

	public List<Temperature> getTemperatureData() 
	{
		return (List<Temperature>) tempRepository.findAll();
	}	
}


