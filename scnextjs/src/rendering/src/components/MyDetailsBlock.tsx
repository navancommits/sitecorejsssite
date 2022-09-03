import { Text, RichText, Field, Image } from '@sitecore-jss/sitecore-jss-nextjs';

type MyDetailsBlockProps =  {
  fields: {
    heading: Field<string>;
    blurb: Field<string>;
    description: Field<string>;
    photo: Field<Image>;
  };
};


const MyDetailsBlock = ({fields}: MyDetailsBlockProps): JSX.Element => {
  return (
    
       <div className="gallery">   
    		<Image field={fields.photo} />  
    		<Text tag="h2" field={fields.heading} />
    		<Text tag="i" field={fields.blurb} />
    		<hr/>
    		<RichText className="desc" field={fields.description} />
  	 </div>  
    
  );

};

export default MyDetailsBlock;


