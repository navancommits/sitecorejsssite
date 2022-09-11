import { Text, RichText, withDatasourceCheck } from '@sitecore-jss/sitecore-jss-nextjs';


type NewLotteryHeaderProps = {
fields: {
    LotteryNo: Field<string>;
    Title: Field<string>;
  };
};

const NewLotteryHeader = ({ fields }): JSX.Element => (
  <div>
    <hr/>
    <h2>Lottery Header from Rendering Contents Resolver</h2>
    <Text field={fields.LotteryNo} /><br/>
    <Text field={fields.Title} />   
    <hr/>
  </div>
);

export default withDatasourceCheck()<NewLotteryHeaderProps>(NewLotteryHeader);
