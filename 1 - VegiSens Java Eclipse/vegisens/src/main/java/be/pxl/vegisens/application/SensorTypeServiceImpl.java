package be.pxl.vegisens.application;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional
public class SensorTypeServiceImpl implements ISensorTypeService
{
	@Autowired
	private SensorTypeRepository sensorTypeRepository;

	public List<SensorType> getAllSensorTypes() 
	{
		return (List<SensorType>) sensorTypeRepository.findAll();
	}

	@Override
	public SensorType getSensorTypeById(int sensorTypeId)
	{
		return sensorTypeRepository.findOne(sensorTypeId);
	}
	
}


