import React from "react";
import { tns } from "tiny-slider/src/tiny-slider";
import logo from "./logo.svg";
import { Button, IconButton, IconName } from "evergreen-ui";
import "./App.css";

const SliderComponent: React.FC = () => {
  const options = {
    items: 1,
    controls: true,
    responsive: {
      350: {
        items: 2,
        controls: true,
        edgePadding: 0,
      },
      525: {
        items: 3
      },
      700: {
        items: 4
      }
    },
    container: ".my-slider",
    swipeAngle: false,
    controlsContainer: ".controls",
    speed: 400
  };

  setTimeout(() => tns(options), 0);

  const Placeholder: React.FC<{ text: string; number: number }> = ({
    text,
    number
  }) => (
    <div style={{ backgroundColor: "aliceblue" }}>
      <img src={text}  alt={"Series image"} />
    </div>
  );
  const elements = ["qwe", "qwe", "qwe", "qwe", "qwe", "qwe", "qwe", "qwe"];

  const Controllers = () => (
    <div className="controls">
      <IconButton
        className="prev"
        data-controls="prev"
        icon="caret-left"
        height={40}
        iconSize={40}
      />
      <IconButton
        className="next"
        data-controls="next"
        icon="caret-right"
        height={40}
      />
    </div>
  );

  const Slider = () => (
    <div className={"my-slider"}>
      {Array.from(Array(10).keys()).map((ele, index) => (
        <Placeholder key={index} text={"http://localhost:8989/MediaCover/20/poster-250.jpg?lastWrite=637100137751372481"} number={index} />
      ))}
    </div>
  );

  return (
    <div>
      <Controllers />
      <Slider />
    </div>
  );
};

const App: React.FC = () => {
  return (
    <div className="App">
      <SliderComponent />
    </div>
  );
};

export default App;
