import { Text, Field, RichText, getFieldValue, withDatasourceCheck } from '@sitecore-jss/sitecore-jss-nextjs';
import StyleguideSpecimen from 'components/styleguide/Styleguide-Specimen';
import { ComponentProps } from 'lib/component-props';
import { StyleguideSpecimenFields } from 'lib/component-props/styleguide';

type StyleguideFieldUsageTextProps = {
    fields: {
      heading: Field<string>;  
      description: Field<string>;     
    };
  };

/**
 * Demonstrates usage of a Text content field within JSS.
 * Text fields are HTML encoded by default.
 */
const MyTestTitleText = ({fields}: StyleguideFieldUsageTextProps): JSX.Element => {
  return (<div>    
    <Text tag="h1" field={fields.heading} />
    <RichText field={fields.description} />
  </div>);
};

export default MyTestTitleText;
