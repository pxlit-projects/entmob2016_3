package be.pxl.vegisens.domain;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

import javax.persistence.*;


@Entity
@Table(name="sensortype")
public class SensorType implements Serializable 
{

	private static final long serialVersionUID = 1L;

	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name="SENSORTYPE_ID")
    private int sensortypeId;
   
    @OneToMany(mappedBy="sensortype", cascade = CascadeType.MERGE)
    private List<TemperatureRegisteredValues> temperatureValues = new ArrayList<TemperatureRegisteredValues>();
    
    @OneToMany(mappedBy="sensortype", cascade = CascadeType.MERGE)
    private List<HumidityRegisteredValues> humidityValues = new ArrayList<HumidityRegisteredValues>();
    
	@Column(name="SENSOR_NAME")
    private String sensorName;

    @Column(name="SENSOR_UNIT")
    private String sensorUnit;

	public int getSensortypeId() {
		return sensortypeId;
	}

	public void setSensortypeId(int sensortypeId) {
		this.sensortypeId = sensortypeId;
	}
	
	public void setSensorName(String sensorName) {
		this.sensorName = sensorName;
	}
	
	public void setSensortypeUnit(String sensorUnit) {
		this.sensorUnit = sensorUnit;
	}
	public List<TemperatureRegisteredValues> getTemperatureValues() {
		return temperatureValues;
	}

	public List<HumidityRegisteredValues> getHumidityValues() {
		return humidityValues;
	}

	public String getSensorName() {
		return sensorName;
	}

	public String getSensorUnit() {
		return sensorUnit;
	}
	
	public String toString()
	{
		return "[SensorTypeID]: " + this.sensortypeId +
			   " [Name]: " + this.sensorName +
			   " [Unit]: " + this.sensorUnit;
	}

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((sensorName == null) ? 0 : sensorName.hashCode());
		result = prime * result + sensortypeId;
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		SensorType other = (SensorType) obj;
		if (sensorName == null) {
			if (other.sensorName != null)
				return false;
		} else if (!sensorName.equals(other.sensorName))
			return false;
		if (sensortypeId != other.sensortypeId)
			return false;
		return true;
	}
	
	
}
