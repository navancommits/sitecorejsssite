import { Text, RichText, withDatasourceCheck } from '@sitecore-jss/sitecore-jss-nextjs';


type LotteryHeaderProps = {
fields: {
    LotteryId: Field<string>;
    LotteryTitle: Field<string>;
  };
};

const LotteryHeader = ({ fields }): JSX.Element => (
  
  <div>
    <hr/>
    <h2>Lottery Header without Rendering Contents resolver</h2>
    <Text field={fields.LotteryId} /><br/>
    <Text field={fields.LotteryTitle} />   
    <hr/>
  </div>
  
);

export default withDatasourceCheck()<LotteryHeaderProps>(LotteryHeader);
