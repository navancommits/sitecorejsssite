import { Text, Field, RichText, withDatasourceCheck } from '@sitecore-jss/sitecore-jss-nextjs';

type MyTitleTextProps = 
   {
    fields: {
      heading: Field<string>;  
      description: Field<string>;     
    };
  };

const MyTitleText = (myprops: MyTitleTextProps): JSX.Element => (
  <div>    
    <Text tag="h1" field={myprops.fields.heading} />
    <RichText field={myprops.fields.description} />
  </div>
);

export default withDatasourceCheck()<MyTitleTextProps>(MyTitleText);
