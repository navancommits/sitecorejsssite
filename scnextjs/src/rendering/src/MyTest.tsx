import Head from 'next/head';

const MyTest = (): JSX.Element => (
  <>
    <Head>
      <title>My Test</title>
    </Head>
    <div style={{ padding: 10 }}>
      <h1>My Test</h1>
      <p>This is my page.</p>
      <a href="/">Go to the Home page</a>
    </div>
  </>
);

export default MyTest;
