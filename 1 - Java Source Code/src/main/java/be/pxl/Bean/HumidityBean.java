package be.pxl.Bean;

import javax.persistence.*;

@Entity
@Table(name="growable_item")
public class HumidityBean {

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="humidity_id")
	private int humidity_id;
	
	@Column(name="max_ideal_humidity")
	private double max_ideal_humidity;
	
	@Column(name="min_ideal_humidity")
	private double min_ideal_humidity;
	
	public int getHumidity_id() {
		return humidity_id;
	}

	public void setHumidity_id(int humidity_id) {
		this.humidity_id = humidity_id;
	}

	public double getMin_ideal_humidity() {
		return min_ideal_humidity;
	}

	public void setMin_ideal_humidity(double min_ideal_humidity) {
		this.min_ideal_humidity = min_ideal_humidity;
	}

	public double getMax_ideal_humidity() {
		return max_ideal_humidity;
	}

	public void setMax_ideal_humidity(double max_ideal_humidity) {
		this.max_ideal_humidity = max_ideal_humidity;
	}


}
