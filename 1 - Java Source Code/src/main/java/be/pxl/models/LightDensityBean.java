package be.pxl.models;

import javax.persistence.*;

@Entity
@Table(name="growable_item")
public class LightDensityBean {

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="light_id")
	private int lightDensity_id;
	
	@Column(name="min_ideal_light")
	private double min_ideal_light;
	
	@Column(name="max_ideal_light")
	private double max_ideal_light;
	
	public int getLightDensity_id() {
		return lightDensity_id;
	}

	public void setLightDensity_id(int lightDensity_id) {
		this.lightDensity_id = lightDensity_id;
	}

	public double getMin_ideal_light() {
		return min_ideal_light;
	}

	public void setMin_ideal_light(double min_ideal_light) {
		this.min_ideal_light = min_ideal_light;
	}

	public double getMax_ideal_light() {
		return max_ideal_light;
	}

	public void setMax_ideal_light(double max_ideal_light) {
		this.max_ideal_light = max_ideal_light;
	}


}
