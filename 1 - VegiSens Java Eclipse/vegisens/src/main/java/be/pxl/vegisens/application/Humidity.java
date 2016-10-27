package be.pxl.vegisens.application;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

import javax.persistence.*;


@Entity
@Table(name="humidity")
public class Humidity implements Serializable 
{
    /**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name="HUMIDITY_ID")
    private int humidityId;
   
    @OneToMany(mappedBy="humidity")
    private List<GrowableItem> growableItems = new ArrayList<GrowableItem>();
    
	@Column(name="MIN_IDEAL_HUMIDITY")
    private double minHumidity;

    @Column(name="MAX_IDEAL_HUMIDITY")
    private double maxHumidity;

	public int getHumidityId() {
		return humidityId;
	}

	public double getMinHumidity() {
		return minHumidity;
	}

	public double getMaxHumidity() {
		return maxHumidity;
	}

	public void setHumidityId(int humidityId) {
		this.humidityId = humidityId;
	}

	public void setMinHumidity(double minHumidity) {
		this.minHumidity = minHumidity;
	}

	public void setMaxHumidity(double maxHumidity) {
		this.maxHumidity = maxHumidity;
	}

	public void setGrowableItems(List<GrowableItem> growableItems) {
		this.growableItems = growableItems;
	}
	
	public String toString()
	{
		return "{[HumidityID]: " + this.humidityId +
			   " [MinHumidity]: " + this.minHumidity +
			   " [MaxHumidity]: " + this.maxHumidity + "}";	
	}
}
