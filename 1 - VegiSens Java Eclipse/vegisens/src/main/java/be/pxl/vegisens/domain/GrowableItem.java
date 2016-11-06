package be.pxl.vegisens.domain;

import java.io.Serializable;
import javax.persistence.*;


@Entity
@Table(name="growable_items")
@NamedQuery(name = "GrowableItem.getGrowableItemByName", query = "select g from GrowableItem g where g.name=?1")
public class GrowableItem implements Serializable 
{

	private static final long serialVersionUID = 1L;

	//private Humidity humidity;
	
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name="ID")
    private int growableItemId;

	//Fetchtype Eager => Load all related entities | Fetype Lazy => Load on demand
    @ManyToOne(fetch = FetchType.EAGER, cascade = CascadeType.MERGE)
    @JoinColumn(name="HUMIDITY_FK", referencedColumnName="HUMIDITY_ID")
    private Humidity humidity;
    
  //Fetchtype Eager => Load all related entities | Fetype Lazy => Load on demand
	@ManyToOne(fetch = FetchType.EAGER, cascade = CascadeType.MERGE)
    @JoinColumn(name="TEMPERATURE_FK", referencedColumnName="TEMPERATURE_ID")
    private Temperature temperature;
    
	@Column(name="NAME")
    private String name;

	@Column(name="DESCRIPTION")
    private String description;

    @Column(name="IMAGE")
    private String image;

	public int getGrowableItemId() {
		return growableItemId;
	}

	public String getName() {
		return name;
	}

	public String getDescription() {
		return description;
	}

	public Humidity getHumidity() {
		return humidity;
	}

	public Temperature getTemperature() {
		return temperature;
	}

	public String getImage() {
		return image;
	}
	
	public void setHumidity(Humidity humidity)
	{
		this.humidity = humidity;
	}
	
    public void setGrowableItemId(int growableItemId) {
		this.growableItemId = growableItemId;
	}

	public void setTemperature(Temperature temperature)
	{
		this.temperature = temperature;	
	}
	
	public void setName(String name) {
		this.name = name;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public void setImage(String image) {
		this.image = image;
	}
	
	public String toString()
	{
		return "[GrowableItemID]: " + this.growableItemId +
			   " [Name]: " + this.name +
			   " [Description]: " + this.description +
			   " [Image]: " + this.image + 	
			   " [Temperature]: " + this.temperature.toString() + 	
			   " [Humidity]: " + this.humidity.toString();
	}
	
    @Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + growableItemId;
		result = prime * result + ((name == null) ? 0 : name.hashCode());
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
		GrowableItem other = (GrowableItem) obj;
		if (growableItemId != other.growableItemId)
			return false;
		if (name == null) {
			if (other.name != null)
				return false;
		} else if (!name.equals(other.name))
			return false;
		return true;
	}
}
