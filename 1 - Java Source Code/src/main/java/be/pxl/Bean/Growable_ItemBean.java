package be.pxl.Bean;

import javax.persistence.*;

@Entity
@Table(name="growable_item")
public class Growable_ItemBean {
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="Id")
	private int Id;
	
	@Column(name="Name")
	private String name;
	
	@Column(name="Description")
	private String Description;
	
	@Column(name="Image")
	private String image;
	
	@OneToOne
	private TemperatureBean temperature;
	
	@OneToOne
	private HumidityBean humidity;
	
	@OneToOne
	private LightDensityBean lightDensity;

	public int getId() {
		return Id;
	}

	public void setId(int id) {
		Id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getDescription() {
		return Description;
	}

	public void setDescription(String description) {
		Description = description;
	}

	public String getImage() {
		return image;
	}

	public void setImage(String image) {
		this.image = image;
	}

	public TemperatureBean getTemperature() {
		return temperature;
	}

	public void setTemperature(TemperatureBean temperature) {
		this.temperature = temperature;
	}

	public HumidityBean getHumidity() {
		return humidity;
	}

	public void setHumidity(HumidityBean humidity) {
		this.humidity = humidity;
	}

	public LightDensityBean getLightDensity() {
		return lightDensity;
	}

	public void setLightDensity(LightDensityBean lightDensity) {
		this.lightDensity = lightDensity;
	}
}
