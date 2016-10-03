package be.pxl.Bean;

import javax.persistence.*;

@Entity
@Table(name="growable_item")
public class TemperatureBean {

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="temperature_id")
	private int temperature_id;
	
	@Column(name="min_ideal_temperature")
	private double min_ideal_temperature;
	
	@Column(name="max_ideal_temperature")
	private double max_ideal_temperature;
	
	public int getTemperature_id() {
		return temperature_id;
	}

	public void setTemperature_id(int temperature_id) {
		this.temperature_id = temperature_id;
	}

	public double getMin_ideal_temperature() {
		return min_ideal_temperature;
	}

	public void setMin_ideal_temperature(double min_ideal_temperature) {
		this.min_ideal_temperature = min_ideal_temperature;
	}

	public double getMax_ideal_temperature() {
		return max_ideal_temperature;
	}

	public void setMax_ideal_temperature(double max_ideal_temperature) {
		this.max_ideal_temperature = max_ideal_temperature;
	}


}
